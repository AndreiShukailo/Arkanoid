using App.Scripts.Libs.Components;

namespace App.Scripts.Libs.Systems
{
    public interface ISystem
    {
        void Init();
        void Update(float dt);
        void Cleanup();
    }
}