using Alternative_yaw_control.settings;
using GTA;
using System.Windows.Forms;
using GTAControl
      = GTA.Control;

namespace Alternative_yaw_control.script
{
    [ScriptAttributes(NoDefaultInstance = true)]
    internal sealed class AlternativeYawControl : Script
    {
        public AlternativeYawControl()
        {
            var keyThatDeterminesTheIncreaseOrDecreaseOfTheValues
                = Keys.NumPad2;

            var settingsManager
                = new SettingsManager();

            var keyForTheYawRight
                = settingsManager
                    .ReturnTheKeyForTheYawRight();

            var keyForTheYawLeft
                = settingsManager
                    .ReturnTheKeyForTheYawLeft();

            var yawSensitivity
                = settingsManager
                    .ReturnTheYawSensitivity();

            var yawRightValue
                = 0.25f;

            var yawLeftValue
                = 0.25f;

            Tick    += (o, e) =>
            {
                if (Game
                        .IsControlJustPressed(GTAControl
                                                    .VehicleExit))
                {
                    IdleThrottle();
                }

                Game
                    .SetControlValueNormalized(GTAControl
                                                    .VehicleFlyYawRight, yawRightValue);
                Game
                    .SetControlValueNormalized(GTAControl
                                                    .VehicleFlyYawLeft, yawLeftValue);

                if (Game
                        .IsKeyPressed(keyForTheYawRight))
                {
                    ApplyingRightYaw();

                    return;
                }

                if (Game
                        .IsKeyPressed(keyForTheYawLeft))
                {
                    ApplyingLeftYaw();

                    return;
                }
            };

            KeyDown += (o, e) =>
            {
                if (e.KeyCode == keyForTheYawRight
                    ||
                    e.KeyCode == keyForTheYawLeft)
                {
                    if (keyThatDeterminesTheIncreaseOrDecreaseOfTheValues == Keys.NumPad2)
                    {
                        keyThatDeterminesTheIncreaseOrDecreaseOfTheValues = e.KeyCode;
                    }
                }
            };

            void IdleThrottle()
            {
                if (yawRightValue != 0.25f)
                    yawRightValue = 0.25f;

                if (yawLeftValue != 0.25f)
                    yawLeftValue = 0.25f;
            }

            void ApplyingRightYaw()
            {
                if (keyThatDeterminesTheIncreaseOrDecreaseOfTheValues == keyForTheYawRight)
                {
                    IncreaseRightYaw();
                }

                if (keyThatDeterminesTheIncreaseOrDecreaseOfTheValues == keyForTheYawLeft)
                {
                    DecreaseRightYaw();
                }

                void IncreaseRightYaw()
                {
                    if (yawRightValue > 1f)
                        yawRightValue = 1f;

                    if (yawRightValue < 1f)
                        yawRightValue += yawSensitivity + (Game.LastFrameTime / 5f);
                }
                
                void DecreaseRightYaw()
                {
                    if (yawLeftValue < 0.25f)
                        yawLeftValue = 0.25f;

                    if (yawLeftValue == 0.25f)
                    {
                        Yield();

                        keyThatDeterminesTheIncreaseOrDecreaseOfTheValues = Keys.NumPad2;
                    }

                    if (yawLeftValue > 0.25f)
                        yawLeftValue -= yawSensitivity + (Game.LastFrameTime / 5f);
                }
            }

            void ApplyingLeftYaw()
            {
                if (keyThatDeterminesTheIncreaseOrDecreaseOfTheValues == keyForTheYawRight)
                {
                    IncreaseLeftYaw();
                }

                if (keyThatDeterminesTheIncreaseOrDecreaseOfTheValues == keyForTheYawLeft)
                {
                    DecreaseLeftYaw();
                }

                void IncreaseLeftYaw()
                {
                    if (yawRightValue < 0.25f)
                        yawRightValue = 0.25f;

                    if (yawRightValue == 0.25f)
                    {
                        Yield();

                        keyThatDeterminesTheIncreaseOrDecreaseOfTheValues = Keys.NumPad2;
                    }

                    if (yawRightValue > 0.25f)
                        yawRightValue -= yawSensitivity + (Game.LastFrameTime / 5f);
                }

                void DecreaseLeftYaw()
                {
                    if (yawLeftValue > 1f)
                        yawLeftValue = 1f;

                    if (yawLeftValue < 1f)
                        yawLeftValue += yawSensitivity + (Game.LastFrameTime / 5f);
                }
            }
        }
    }
}