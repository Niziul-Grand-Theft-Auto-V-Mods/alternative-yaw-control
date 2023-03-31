using System.Drawing;

namespace Alternative_yaw_control.user_interfaces.creators.resources.interfaces
{
    internal interface IConfiguration
    {
        Color Color
        { get; set; }

        PointF Position
        { get; set; }
    }
}