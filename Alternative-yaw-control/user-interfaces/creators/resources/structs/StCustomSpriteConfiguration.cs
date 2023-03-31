using System.Drawing;

using Alternative_yaw_control.user_interfaces.creators.resources.interfaces;


namespace Alternative_yaw_control.user_interfaces.creators.resources.structs
{
    internal struct StCustomSpriteConfiguration : IConfiguration
    {
        public SizeF Size
        { get; set; }

        public Color Color
        { get; set; }

        public PointF Position
        { get; set; }
        
        public string Filename
        { get; set; }
    }
}
