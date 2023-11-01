namespace App.Scripts.Libs.AssetProvider
{
    public interface IAssetProvider<out TObject> where TObject : class
    {
        public TObject Load(string path);
    }
}