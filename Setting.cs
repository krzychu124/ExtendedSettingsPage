using System;
using System.Collections.Generic;
using Colossal;
using Colossal.IO.AssetDatabase;
using Game.Input;
using Game.Modding;
using Game.Settings;
using Game.UI.Menu;

namespace ExtendedSettingsPage
{
    [FileLocation(nameof(ExtendedSettingsPage))]
    [SettingsUIGroupOrder(kKeybindingGroup)]
    [SettingsUIShowGroupName(kKeybindingGroup)]
    [SettingsUIKeyboardAction(Mod.kButtonActionName, ActionType.Button, usages: new string[] { Usages.kMenuUsage, "TestUsage" }, interactions: new string[] { "UIButton" })]
    [SettingsUIGamepadAction(Mod.kButtonActionName, ActionType.Button, usages: new string[] { Usages.kMenuUsage, "TestUsage" }, interactions: new string[] { "UIButton" })]
    [SettingsUIMouseAction(Mod.kButtonActionName, ActionType.Button, usages: new string[] { Usages.kMenuUsage, "TestUsage" }, interactions: new string[] { "UIButton" })]
    public partial class Setting : ModSetting
    {
        public const string kSection = "Main";

        public const string kKeybindingGroup = "KeyBinding";

        public Setting(IMod mod) : base(mod) { }

        [UIAttributes.CustomUIExtendedKeybinding("coui://ui-mods/Icons/Straight.svg", BindingKeyboard.Q, Mod.kButtonActionName, shift: true)]
        [SettingsUISection(kSection, kKeybindingGroup)]
        public ProxyBinding KeyboardBinding { get; set; }

        [SettingsUISection(kSection, kKeybindingGroup)]
        public bool ResetBindings
        {
            set {
                Mod.log.Info("Reset key bindings");
                ResetKeyBindings();
            }
        }

        public override void SetDefaults()
        {
            throw new NotImplementedException();
        }

        public override AutomaticSettings.SettingPageData GetPageData(string pageId, bool addPrefix)
        {
            return GeneratePage(pageId, addPrefix);
        }
    }

    public class LocaleEN : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleEN(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "ExtendedSettingsPage" },
                { m_Setting.GetOptionTabLocaleID(Setting.kSection), "Main" },

                { m_Setting.GetOptionGroupLocaleID(Setting.kKeybindingGroup), "Key bindings" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.KeyboardBinding)), "Keyboard binding" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.KeyboardBinding)), $"Keyboard binding of Button input action" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetBindings)), "Reset key bindings" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetBindings)), $"Reset all key bindings of the mod" },

                { m_Setting.GetBindingKeyLocaleID(Mod.kButtonActionName), "Button key" },

                { m_Setting.GetBindingMapLocaleID(), "Mod settings sample" },
            };
        }

        public void Unload() { }
    }
}
