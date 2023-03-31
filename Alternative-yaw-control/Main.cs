using GTA;
using GTAControl
      = GTA.Control;

using System.Windows.Forms;

using CTimer
      = Alternative_yaw_control.tools.Timer;

using Alternative_throttle_control.settings;

namespace Alternative_yaw_control
{
    internal class Main : Script
    {
        private readonly Keys _keyForTheYawRigth;

        private readonly Keys _keyForTheYawLeft;

        private float _yawSensitivity;

        private float _yawRigthValue;

        private float _yawLeftValue;

        public Main()
        {
            var keyThatDeterminesTheIncreaseOrDecreaseOfTheValues
                = Keys.NumPad2;

            var timer
                = new CTimer();

            var settingsManager
                = new SettingsManager();

            _keyForTheYawRigth
                = settingsManager
                    .ReturnTheKeyForTheYawRight();

            _keyForTheYawLeft
                = settingsManager
                    .ReturnTheKeyForTheYawLeft();

            _yawSensitivity
                = settingsManager
                    .ReturnTheYawSensitivity();

            _yawRigthValue
                = 0.25f;
            _yawLeftValue
                = 0.25f;

            Tick    += (o, e) =>
            {
                switch (Game.Player.Character.IsInFlyingVehicle)
                {
                    case false:
                        {
                            if (_yawRigthValue != 0.25f)
                                _yawRigthValue = 0.25f;

                            if (_yawLeftValue != 0.25f)
                                _yawLeftValue = 0.25f;
                        }
                        return;
                    case true:
                        {
                            Game
                                .SetControlValueNormalized(GTAControl
                                                                .VehicleFlyYawRight, _yawRigthValue);
                            Game
                                .SetControlValueNormalized(GTAControl
                                                                .VehicleFlyYawLeft, _yawLeftValue);


                            if (Game
                                    .IsKeyPressed(_keyForTheYawRigth))
                            {
                                if (keyThatDeterminesTheIncreaseOrDecreaseOfTheValues == _keyForTheYawRigth)
                                {
                                    if (_yawRigthValue > 1f)
                                        _yawRigthValue = 1f;

                                    if (_yawRigthValue < 1f)
                                        _yawRigthValue += _yawSensitivity;
                                }

                                if (keyThatDeterminesTheIncreaseOrDecreaseOfTheValues == _keyForTheYawLeft)
                                {
                                    if (_yawLeftValue < 0.25f)
                                        _yawLeftValue = 0.25f;

                                    if (timer
                                            .ReturnsTrueForEach(1))
                                    {
                                        if (_yawLeftValue == 0.25f)
                                            keyThatDeterminesTheIncreaseOrDecreaseOfTheValues = Keys.NumPad2;
                                    }

                                    if (_yawLeftValue > 0.25f)
                                        _yawLeftValue -= _yawSensitivity;
                                }

                                return;
                            }

                            if (Game
                                    .IsKeyPressed(_keyForTheYawLeft))
                            {
                                if (keyThatDeterminesTheIncreaseOrDecreaseOfTheValues == _keyForTheYawRigth)
                                {
                                    if (_yawRigthValue < 0.25f)
                                        _yawRigthValue = 0.25f;

                                    if (timer
                                            .ReturnsTrueForEach(1))
                                    {
                                        if (_yawRigthValue == 0.25f)
                                            keyThatDeterminesTheIncreaseOrDecreaseOfTheValues = Keys.NumPad2;
                                    }

                                    if (_yawRigthValue > 0.25f)
                                        _yawRigthValue -= _yawSensitivity;
                                }

                                if (keyThatDeterminesTheIncreaseOrDecreaseOfTheValues == _keyForTheYawLeft)
                                {
                                    if (_yawLeftValue > 1f)
                                        _yawLeftValue = 1f;

                                    if (_yawLeftValue < 1f)
                                        _yawLeftValue += _yawSensitivity;
                                }
                                return;
                            }
                        }
                        return;
                } 
            };

            KeyDown += (o, e) =>
            {
                if (e.KeyCode == _keyForTheYawRigth
                    ||
                    e.KeyCode == _keyForTheYawLeft)
                {
                    if (keyThatDeterminesTheIncreaseOrDecreaseOfTheValues == Keys.NumPad2)
                    {
                        keyThatDeterminesTheIncreaseOrDecreaseOfTheValues = e.KeyCode;
                    }
                }
            };
        }
    }
}