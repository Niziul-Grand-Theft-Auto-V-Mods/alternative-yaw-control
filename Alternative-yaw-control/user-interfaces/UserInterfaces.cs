using GTA;

using Alternative_throttle_control.settings;

using Alternative_yaw_control.user_interfaces.interfaces;

namespace Alternative_yaw_control.user_interfaces
{
    internal sealed class UserInterface : Script
    {
        public UserInterface()
        {
            var yawInterface
                = new YawInterface();

            var settingsManager
                = new SettingsManager();

            if (!settingsManager
                    .ReturnTheInterfaceVisibility())
            {
                Pause();
            }

            Tick += (o, e) =>
            {
                if (Game.IsLoading)
                {
                    return;
                }

                switch (Game.Player.Character.IsInFlyingVehicle)
                {
                    case true:
                        {
                            yawInterface
                                .BuildTheInterface();
                            
                            yawInterface
                                .ShowTheInterface();
                        }
                        return;
                    case false:
                        {
                            yawInterface
                                .RemoveTheInterface();
                        }
                        return;
                }
            };

            Aborted += (o, e) =>
            {
                yawInterface
                    .RemoveTheInterface();
            };
        }
    }
}