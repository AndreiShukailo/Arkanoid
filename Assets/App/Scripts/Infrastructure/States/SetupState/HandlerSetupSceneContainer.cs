using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Scripts.Infrastructure.States.SetupState
{
    public class HandlerSetupSceneContainer : IHandlerSetupScene
    {
        private readonly List<IHandlerSetupScene> _handlers;

        public HandlerSetupSceneContainer(IEnumerable<IHandlerSetupScene> handlerSetupLevels)
        {
            _handlers = handlerSetupLevels.ToList();
        }

        public async Task Process()
        {
            foreach (var handler in _handlers) await handler.Process();
        }
    }
}