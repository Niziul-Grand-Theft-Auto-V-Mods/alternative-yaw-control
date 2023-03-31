using GTA;

using Alternative_yaw_control.settings;

using Alternative_yaw_control.user_interfaces.interfaces;

namespace Alternative_yaw_control.user_interfaces
{
    [ScriptAttributes(NoDefaultInstance = true)]
    internal sealed class UserInterfaces : Script
    {
        public UserInterfaces()
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
                if (Game
                        .IsControlJustPressed(Control
                                                .VehicleExit))
                {
                    Wait(5000);

                    return;
                }

                yawInterface
                    .BuildTheInterface();

                yawInterface
                    .ShowTheInterface();
            };

            Aborted += (o, e) =>
            {
                yawInterface
                    .RemoveTheInterface();
            };
        }
    }
}