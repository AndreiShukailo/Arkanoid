using App.Scripts.Infrastructure.Buttons.View;
using App.Scripts.Libs.Pool;

namespace App.Scripts.Infrastructure.Buttons.Factory
{
    public class ButtonFactory : PoolFactory<ButtonView>
    {
        public ButtonFactory(PoolSetting<ButtonView> poolSetting) : base(poolSetting)
        {
        }

        public override ButtonView Create()
        {
            return _poolProvider.ObjectPool.Spawn();
        }
    }
}