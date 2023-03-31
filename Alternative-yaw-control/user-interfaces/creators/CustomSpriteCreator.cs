using GTA.UI;

using Alternative_yaw_control.user_interfaces.creators.resources.structs;


namespace Alternative_yaw_control.user_interfaces.creators
{
    internal abstract class CustomSpriteCreator
    {
        protected CustomSprite CreateAndReturnAnCustomSpriteWithThis(StCustomSpriteConfiguration stCustomSpriteConfiguration)
        {
            return _
                   = new CustomSprite(stCustomSpriteConfiguration
                                                            .Filename,
                                      stCustomSpriteConfiguration
                                                            .Size,
                                      stCustomSpriteConfiguration
                                                            .Position,
                                      stCustomSpriteConfiguration
                                                            .Color);
        }
    }
}
