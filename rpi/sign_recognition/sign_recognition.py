import cv2 as cv
import numpy as np
import sys

class Object(object):
    pass

class SignRecognizer(object):

    def __init__(self, modelPath, cfgPath, threshold, net_input_width, net_input_height):
        # Set network arguments
        self.args = Object()
        self.args.scale = 0.00392
        self.args.thr = threshold
        self.args.nms = 0.4
        self.args.target = cv.dnn.DNN_TARGET_CPU
        self.args.backend = cv.dnn.DNN_BACKEND_DEFAULT
        self.args.model = modelPath
        self.args.config = cfgPath
        self.args.width = net_input_width
        self.args.height = net_input_height
        self.args.rgb = True
        self.net = cv.dnn.readNet(cv.samples.findFile(self.args.model), cv.samples.findFile(self.args.config))
        # Load a network
        self.net.setPreferableBackend(self.args.backend)
        self.net.setPreferableTarget(self.args.target)
        self.outNames = self.net.getUnconnectedOutLayersNames()

    def __postprocess__(self, frame, outs):
        frameHeight = frame.shape[0]
        frameWidth = frame.shape[1]

        layerNames = self.net.getLayerNames()
        lastLayerId = self.net.getLayerId(layerNames[-1])
        lastLayer = self.net.getLayer(lastLayerId)

        classIds = []
        confidences = []
        boxes = []
        # Network produces output blob with a shape NxC where N is a number of
        # detected objects and C is a number of classes + 4 where the first 4
        # numbers are [center_x, center_y, width, height]  
        for out in outs:
            for detection in out:
                scores = detection[5:]
                classId = np.argmax(scores)
                confidence = scores[classId]
                if confidence > self.args.thr:
                    center_x = int(detection[0] * frameWidth)
                    center_y = int(detection[1] * frameHeight)
                    width = int(detection[2] * frameWidth)
                    height = int(detection[3] * frameHeight)
                    left = int(center_x - width / 2)
                    top = int(center_y - height / 2)
                    classIds.append(classId)
                    confidences.append(float(confidence))
                    boxes.append([left, top, width, height])

        indices = cv.dnn.NMSBoxes(boxes, confidences, self.args.thr, self.args.nms)
        detections = []
        for i in indices:
            index = i
            i = i[0]
            box = boxes[i]
            detections.append([confidences[i], int(classIds[i]), box])
        return detections

    def process(self, frame):
        blob = cv.dnn.blobFromImage(frame, size=(self.args.width, self.args.width), swapRB=self.args.rgb, ddepth=cv.CV_8U)
        # Run a model
        self.net.setInput(blob, scalefactor=self.args.scale)
        outs = self.net.forward(self.outNames)
        return self.__postprocess__(frame, outs)
