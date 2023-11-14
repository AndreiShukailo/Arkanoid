using System.Threading.Tasks;
using App.Scripts.Infrastructure.States.SetupState;

namespace App.Scripts.Scenes.PackSelectScene.Features.PacksFeature
{
    public class HandlerCreatePacks : IHandlerSetupScene
    {
        private readonly PacksCreator _packsCreator;

        public HandlerCreatePacks(PacksCreator packsCreator)
        {
            _packsCreator = packsCreator;
        }

        public Task Process()
        {
            _packsCreator.CreatePacks();
            
            return Task.CompletedTask;
        }
    }
}