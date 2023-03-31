using Alternative_yaw_control.script;
using Alternative_yaw_control.user_interfaces;
using GTA;

namespace Alternative_yaw_control
{
    internal sealed class Main : Script
    {
        private AlternativeYawControl _alternativeYawControl;

        private UserInterfaces _userInterfaces;

        public Main()
        {
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
                            if (_alternativeYawControl is null
                                ||
                                _userInterfaces is null)
                            {
                                _alternativeYawControl
                                    = InstantiateScript<AlternativeYawControl>();

                                _userInterfaces
                                    = InstantiateScript<UserInterfaces>();

                                _alternativeYawControl
                                    .Resume();

                                _userInterfaces
                                    .Resume();
                            }

                            if (_alternativeYawControl.IsPaused
                                ||
                                _userInterfaces.IsPaused)
                            {
                                _alternativeYawControl
                                    .Resume();

                                _userInterfaces
                                    .Resume();
                            }
                        }
                        return;
                    case false:
                        {
                            if (_alternativeYawControl is null
                                ||
                                _userInterfaces is null)
                            {
                                return;
                            }

                            if (_alternativeYawControl.IsPaused
                                ||
                                _userInterfaces.IsPaused)
                            {
                                return;
                            }

                            _alternativeYawControl
                                .Pause();

                            _userInterfaces
                                .Pause();
                        }
                        return;
                }

                Interval = 2000;
            };

            Aborted += (o, e) =>
            {
                if (_alternativeYawControl is null
                    ||
                    _userInterfaces is null)
                {
                    return;
                }

                _alternativeYawControl
                    .Abort();

                _userInterfaces
                    .Abort();

                _alternativeYawControl
                    = null;

                _userInterfaces
                    = null;
            };
        }
    }
}
