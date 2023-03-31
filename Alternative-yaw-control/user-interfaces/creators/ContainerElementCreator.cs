using GTA.UI;

using Alternative_yaw_control.user_interfaces.creators.resources.structs;

namespace Alternative_yaw_control.user_interfaces.creators
{
    internal abstract class ContainerElementCreator
    {
        protected ContainerElement CreateAndReturnAnContainerWithThis(StContainerElementConfiguration stContainerElementConfiguration)
        {
            return _
                   = new ContainerElement(stContainerElementConfiguration
                                                                    .Position,
                                          stContainerElementConfiguration
                                                                    .Size,
                                          stContainerElementConfiguration
                                                                    .Color);
        }
    }
}