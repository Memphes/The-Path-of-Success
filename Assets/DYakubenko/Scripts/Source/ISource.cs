namespace DYakubenko
{
    public interface ISource
    {
        public int GetSource(string nameSource, int count);


        public int AddSource(string nameSource, int count);
        
        
    }
}