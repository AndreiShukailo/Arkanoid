using System.Threading.Tasks;
using App.Scripts.Infrastructure.Buttons;
using App.Scripts.Infrastructure.SceneManagement;
using App.Scripts.Infrastructure.States.SetupState;
using App.Scripts.Infrastructure.UIMenegement;

namespace App.Scripts.Scenes.GameScene.GameStates
{
    public class StateSetupGameScene : StateSetupScene
    {
        private readonly IHandlerSetupScene _afterCurtains;
        private readonly BlockUIController _blockUIController;

        public StateSetupGameScene(IHandlerSetupScene handlerSetupScenes, SceneLoaderController sceneLoaderController,
            ButtonManager buttonManager, IHandlerSetupScene afterCurtains, BlockUIController blockUIController) : base(handlerSetupScenes, sceneLoaderController, buttonManager)
        {
            _afterCurtains = afterCurtains;
            _blockUIController = blockUIController;
        }

        protected override async Task SetupAfterCurtains()
        {
            _blockUIController.SetBlocked(true);
            await _afterCurtains.Process();
            _blockUIController.SetBlocked(false);
        }
    }
}