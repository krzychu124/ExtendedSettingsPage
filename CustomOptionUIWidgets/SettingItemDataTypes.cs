using Game.UI.Menu;
using Game.UI.Widgets;

namespace ExtendedSettingsPage.CustomOptionUIWidgets
{
    public static class SettingItemDataTypes
    {
        /// <summary>
        /// Setting item data representing Extended Keybinding field on the settings page
        /// </summary>
        public class ExtendedKeybindingSettingItemData : AutomaticSettings.SettingItemData
        {
            private readonly string m_Icon;

            public ExtendedKeybindingSettingItemData(string icon, Game.Settings.Setting setting, AutomaticSettings.IProxyProperty property, string prefix) : base(AutomaticSettings.WidgetType.None, setting, property, prefix)
            {
                m_Icon = icon;
            }

            protected override IWidget GetWidget()
            {
                return new Widgets.ExtendedKeybindingField(m_Icon, this);
            }
        }
    }
}
