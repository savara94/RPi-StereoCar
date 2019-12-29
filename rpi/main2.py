from flask import Flask, render_template, make_response, request, jsonify, Response
from flask_cors import CORS
import cv2
import threading
import time
import sys
from arexx.arexx import Arexx
from sign_recognition.sign_recognition import SignRecognizer
from pathlib import Path

caps = []
frames = []
jpegs = []
detections = []
running = True

arexx = Arexx('/dev/ttyUSB0')
time.sleep(1)
abs_dir_path = str(Path().absolute())
model_path = abs_dir_path + '/yolov3-tiny_obj-rpi-car_final.weights'
cfg_path = abs_dir_path + '/yolov3-tiny_obj-rpi-car.cfg'
recognizer = SignRecognizer(model_path, cfg_path, 0.2, 256, 256)
app = Flask(__name__)
CORS(app)

def arexx_updater(name):
    global running
    global arexx
    while(running):
       arexx.update_state()
       time.sleep(0.25)

def frame_updater(name):
    global running
    global caps
    global frames
    global jpegs
    for i in range(0, len(caps)):
        frames.append(None)
        jpegs.append(None)

    while(running):
        for i in range(0, len(caps)):
            ret, frames[i] = caps[i].read()
            if ret == True:
                ret, tmpJpeg = cv2.imencode('.jpg', frames[i])
                if ret == True:
                    jpegs[i] = tmpJpeg.tobytes()

def detection_updater(name):
    global running
    global recognizer
    global detections
    for i in range(0, len(caps)):
        detections.append(None)
    while(running):
        for i in range(0, len(caps)):
            if frames[i] is not None:
                detections[i] = recognizer.process(frames[i])

@app.route('/')
def index():
    data = {
        'message' : 'OK'
    }

    return jsonify(data)

@app.route('/car/information')
def distance_readings():
    global arexx

    resp = {
    'arexx': arexx.state,
    'message': 'OK'
    }

    return jsonify(resp)

@app.route('/car/detections')
def detection_readings():
    global detections

    print(detections)
    resp = {
        'detections': detections,
        'message': 'OK'
    }

    return jsonify(resp)

@app.route('/car/move', methods=['POST'])
def move():
    data = request.json
    direction = data['direction']
    arexx.move(direction)

    resp = {
	'message' : 'OK'
    }

    return jsonify(resp)

@app.route('/car/track', methods=['POST'])
def track():
    command = 'track'
    arexx.track()

    resp = {
        'message' : 'OK'
    }

    return jsonify(resp)

@app.route('/car/gear', methods=['POST'])
def gear():
   data = request.json
   gear = data['gear']
   arexx.change_gear(gear)

   resp = {
       'message' : 'OK'
   }

   return jsonify(resp)

@app.route('/car/reset', methods=['POST'])
def reset():
    arexx.reset_pose()

    resp = {
    'message': 'OK'
    }

    return jsonify(resp)

@app.route('/car/video_feed/<id>')
def video_feed(id):
    global jpegs
    jpeg = jpegs[int(id)]
    if jpeg != None:
        response = make_response(jpeg)
        response.headers.set('Content-Type', 'image/jpeg')
        response.headers.set(
        'Content-Disposition', 'attachment', filename='img.jpg')
        return response
    	#return Response(gen(int(id)), mimetype='multipart/x-mixed-replace; boundary=frame')
    response = make_response('', 404)
    return response

if __name__ == '__main__':
    firstCamIndex = int(sys.argv[1])
    secondCamIndex = int(sys.argv[2])
    caps.append(cv2.VideoCapture(firstCamIndex))
    caps.append(cv2.VideoCapture(secondCamIndex))

    time.sleep(1)

    arexx_thread = threading.Thread(target = arexx_updater, args=(1,))
    arexx_thread.start()

    frame_thread = threading.Thread(target = frame_updater, args=(1,))
    frame_thread.start()

    detection_thread = threading.Thread(target = detection_updater, args=(1,))
    detection_thread.start()

    app.run(host='0.0.0.0')
    running = False

    arexx_thread.join()
    frame_thread.join()
    detection_thread.join()

