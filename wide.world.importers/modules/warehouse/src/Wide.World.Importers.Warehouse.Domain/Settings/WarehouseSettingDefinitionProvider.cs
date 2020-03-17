using Volo.Abp.Settings;

namespace Wide.World.Importers.Warehouse.Settings
{
    public class WarehouseSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(WarehouseSettings.MySetting1));
        }
    }
}
