using App.Scripts.Libs.ServiceLocator;

namespace App.Scripts.Libs.Installer
{
    public class ProjectContext : MonoContext
    {
        public static ProjectContext Instance;
        public ServiceContainer ServiceContainer { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(this);
            Setup();
        }

        protected override ServiceContainer CreateContainer()
        {
            return new ServiceContainer();
        }

        protected override void Setup()
        {
            ServiceContainer = BuildContainer();
        }
    }
}