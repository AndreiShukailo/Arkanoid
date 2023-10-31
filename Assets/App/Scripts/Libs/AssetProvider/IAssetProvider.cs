namespace App.Scripts.Libs.AssetProvider
{
    public interface IAssetProvider<TObject> where TObject : class
    {
        public TObject Load(string path);
    }
}