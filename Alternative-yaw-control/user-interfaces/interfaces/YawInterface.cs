using GTA;
using GTA.UI;
using GTAFont
      = GTA.UI.Font;

using System.Drawing;

using Alternative_yaw_control.settings;

using Alternative_yaw_control.user_interfaces.managers;

namespace Alternative_yaw_control.user_interfaces.interfaces
{
    internal class YawInterface
    {
        private ContainerElement _containerElement;

        private SettingsManager _settingsManager;

        private TextElement[] _textElements;

        private PointF _interfaceMiddlePosition;
        
        public YawInterface()
        {
            _settingsManager
                = new SettingsManager();
        }

        internal void BuildTheInterface()
        {
            if (_containerElement != null)
            {
                return;
            }

            _containerElement
                = ReturnContainerElementForTheYawInterface();

            var customSprites
                = new[]
                {
                    ReturnCustomSpriteDefaultLayout(),
                    ReturnCustomSpriteLine()
                };

            _containerElement
                .Items.Add(customSprites[0]);

            _containerElement
                .Items.Add(customSprites[1]);

            if (_textElements != null)
            {
                return;
            }

            _textElements
                = new[]
                {
                    ReturnTextElementYawRight(),
                    ReturnTextElementYawLeft()
                };

            _containerElement
                .Items.Add(_textElements[0]);

            _containerElement
                .Items.Add(_textElements[1]);
        }

        internal void ShowTheInterface()
        {
            UpdateTheYawLine();

            _containerElement
                .ScaledDraw();
        }

        private void UpdateTheYawLine()
        {
            var yawRightValue
                = Game
                    .GetControlValueNormalized(Control.VehicleFlyYawRight);

            if (yawRightValue != 0f)
            {
                var updatePosition
                    = new PointF(_interfaceMiddlePosition.X + (yawRightValue * 117.5f),
                                 _interfaceMiddlePosition.Y);

                _textElements[0]
                    .Caption = $"{yawRightValue * 100f:N1}% - YawRigth";

                _containerElement
                    .Items[1]
                            .Position = updatePosition;
                
                return;
            }

            _textElements[0]
                    .Caption = $"0% - YawRigth";

            var yawLeftValue
                = Game
                    .GetControlValueNormalized(Control.VehicleFlyYawLeft);

            if (yawLeftValue != 0f)
            {
                var updatePosition
                    = new PointF(_interfaceMiddlePosition.X - (yawLeftValue * 117.5f),
                                 _interfaceMiddlePosition.Y);

                _textElements[1]
                    .Caption = $"YawLeft: {yawLeftValue * 100f:N1}%";

                _containerElement
                    .Items[1]
                            .Position = updatePosition;

                return;
            }

            _textElements[1]
                    .Caption = $"YawLeft - 0%";

            if (_interfaceMiddlePosition != new PointF(0f, -2f))
            {
                _interfaceMiddlePosition
                    = new PointF(0f, -2.5f);

                _containerElement
                    .Items[1]
                            .Position = _interfaceMiddlePosition;
            }
        }

        internal void RemoveTheInterface()
        {
            if (_containerElement == null)
            {
                return;
            }

            _textElements
                = null;

            _containerElement
                .Items.Clear();

            _containerElement
                = null;
        }

        private ContainerElement ReturnContainerElementForTheYawInterface()
        {
            var containerElement
                = new ContainerElement();

            var customSpriteDefaultLayout
                = ReturnTheCustomSpritesOfThis("DefaultLayout");

            containerElement
                .Position = customSpriteDefaultLayout
                                                .Position;

            containerElement
                .Size = customSpriteDefaultLayout
                                                .Size;

            containerElement
                .Centered = false;

            return _
                   = containerElement;
        }

        private CustomSprite ReturnCustomSpriteDefaultLayout()
        {
            var customSpriteDefaultLayout
                = ReturnTheCustomSpritesOfThis(filename: "DefaultLayout");

            customSpriteDefaultLayout
                .Centered = true;

            customSpriteDefaultLayout
                .Position = PointF.Empty;

            return _
                   = customSpriteDefaultLayout;
        }
        private CustomSprite ReturnCustomSpriteLine()
        {
            var customSpriteLine
                = ReturnTheCustomSpritesOfThis(filename: "Line");

            customSpriteLine
                .Centered = true;

            customSpriteLine
                .Position = PointF.Empty;

            return _
                   = customSpriteLine;
        }
        private CustomSprite ReturnTheCustomSpritesOfThis(string filename)
        {
            var customSpriteManager
                = new CustomSpriteManager();

            var customSprite
                = customSpriteManager
                        .ReturnAnCustomSpriteWithThis(_settingsManager
                                                            .ReturnStCustomSpriteConfigurationOfThis(filename));

            return _
                   = customSprite;
        }

        private TextElement ReturnTextElementYawRight()
        {
            var textElementFlyYawRight
                = ReturnTheTextElementOfThis("YawRight");

            textElementFlyYawRight
                .Font = GTAFont.Pricedown;

            textElementFlyYawRight
                .Alignment = Alignment.Left;

            textElementFlyYawRight
                .Position = new PointF(14, 8f);

            return _
                   = textElementFlyYawRight;
        }
        private TextElement ReturnTextElementYawLeft()
        {
            var textElementFlyYawLeft
                = ReturnTheTextElementOfThis("YawLeft");

            textElementFlyYawLeft
                .Font = GTAFont.Pricedown;

            textElementFlyYawLeft
                .Alignment = Alignment.Right;

            textElementFlyYawLeft
                .Position = new PointF(-12f, 8f);

            return _
                   = textElementFlyYawLeft;
        }
        private TextElement ReturnTheTextElementOfThis(string caption)
        {
            var textElementManager
                = new TextElementManager();

            var textElement
                = textElementManager
                        .ReturnAnTextElementWithThis(_settingsManager
                                                            .ReturnStTextElementConfigurationOfThis(caption));

            return _
                   = textElement;
        }
    }
}