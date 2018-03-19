namespace OrderWords
{
    struct WordCount
    {
        public string Word;
        public int Count;

        public WordCount(string v1, int v2)
        {
            this.Word = v1;
            this.Count = v2;
        }

        public override string ToString()
        {
            return $"{Word} - {Count}";
        }
    }
}