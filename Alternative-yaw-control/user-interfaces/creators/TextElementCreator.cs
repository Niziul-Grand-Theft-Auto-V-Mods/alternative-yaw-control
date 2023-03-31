using GTA.UI;

using Alternative_yaw_control.user_interfaces.creators.resources.structs;


namespace Alternative_yaw_control.user_interfaces.creators
{
    internal abstract class TextElementCreator
    {
        protected TextElement CreateAndReturnAnTextElementWithThis(StTextElementConfiguration stTextElementConfiguration)
        {
            return _
                   = new TextElement(stTextElementConfiguration
                                                        .Caption,
                                     stTextElementConfiguration
                                                        .Position,
                                     stTextElementConfiguration
                                                        .Scale,
                                     stTextElementConfiguration
                                                        .Color);
        }
    }
}
