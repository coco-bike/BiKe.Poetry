using Volo.Abp.Settings;

namespace BiKe.Poetry.Settings
{
    public class PoetrySettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(PoetrySettings.MySetting1));
        }
    }
}
