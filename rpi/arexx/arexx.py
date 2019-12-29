import serial
import time
from math import radians, sin, cos

class Arexx(object):
    '''Class used for retrieving information from the robot'''

    # Wheel radius is 2 centimeters
    WHEEL_RADIUS = 0.02
    # Half axis length is 5 centimeters
    HALF_AXIS_LENGTH = 0.05
    # One revolution produces turn by 18 degrees (20 revolutions equals one whole turn)
    REVOLUTION_RAD  = radians(18)

    def __init__(self, serial_device):
        self.__ser__ = serial.Serial(serial_device)
        self.__cmds__ = {
            'left' : b'a',
            'right': b'd',
            'forward': b'w',
            'backward': b's',
            'gear_up': b'q',
            'gear_down': b'e',
            'information':b'i'
        }

        self.state = {}
        self.pose = [0, 0, 0]
        self.prev_timestamp = None
        self.left_wheel_revs_prev = 0
        self.right_wheel_revs_prev = 0

    def move(self, direction):
        if direction in self.__cmds__:
            cmd= self.__cmds__[direction]
            self.__ser__.write(cmd)

    def __read__(self):
        cmd = self.__cmds__['information']
        self.__ser__.write(cmd)
        line =  self.__ser__.readline().decode()
        line = line.replace('\r\n', '');
        splits = line.split(';')
        return {
        'distances': [float(splits[0]) / 10],
        'left_wheel': int(splits[1]),
        'right_wheel': int(splits[2]),
        'gear': int(splits[3]),
        'left_line': int(splits[4]),
	'right_line': int(splits[5]),
        'timestamp': time.time()
        }

    def change_gear(self, gear):
        if gear in self.__cmds__:
            cmd = self.__cmds__[gear]
            self.__ser__.write(cmd)

    def track(self):
        self.__ser__.write('t')

    def __calculate_pose__(self, left_wheel_revs, right_wheel_revs):
        meters_diff = 0
        theta_diff = 0

        left_wheel_rads = left_wheel_revs * self.REVOLUTION_RAD
        right_wheel_rads = right_wheel_revs * self.REVOLUTION_RAD
        left_wheel_rads_prev = self.left_wheel_revs_prev * self.REVOLUTION_RAD
        right_wheel_rads_prev = self.right_wheel_revs_prev * self.REVOLUTION_RAD

        leftDiff = left_wheel_rads - left_wheel_rads_prev
        rightDiff = right_wheel_rads - right_wheel_rads_prev

        meters_diff = self.WHEEL_RADIUS * (leftDiff + rightDiff)
        theta_diff = (self.WHEEL_RADIUS / self.HALF_AXIS_LENGTH) * (rightDiff - leftDiff)

        x = self.pose[0]
        y = self.pose[1]
        theta = self.pose[2]

        self.pose = [x + meters_diff * cos(theta_diff), y + meters_diff * sin(theta_diff), theta + theta_diff]

    def update_state(self):
        data = self.__read__()
        self.__calculate_pose__(data['left_wheel'], data['right_wheel'])
        self.left_wheel_revs_prev = data['left_wheel']
        self.right_wheel_revs_prev = data['right_wheel']

        data['pose'] = self.pose
        self.state = data

    def reset_pose(self):
        self.pose = [0,0,0]
