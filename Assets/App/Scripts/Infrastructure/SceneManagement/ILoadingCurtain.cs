using System.Threading.Tasks;

namespace App.Scripts.Infrastructure.SceneManagement
{
    public interface ILoadingCurtain
    {
        public Task ProcessHide();
        public Task ProcessShow();
    }
}