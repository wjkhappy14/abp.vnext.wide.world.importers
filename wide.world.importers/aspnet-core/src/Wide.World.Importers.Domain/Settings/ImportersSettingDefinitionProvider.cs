using Volo.Abp.Settings;

namespace Wide.World.Importers.Settings
{
    public class ImportersSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(ImportersSettings.MySetting1));
        }
    }
}
