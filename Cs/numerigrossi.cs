class CHugeNumber
{
	private const int N = 200; 
	private int[] _cifre;
	public int[] cifre
	{
		get { return _cifre; }
		set { _cifre = value; }
	}
	public CHugeNumber()
	{
		cifre = new int[N];
	}
	public CHugeNumber(string numero) :this()
	{
		if(numero.Length < N)
		{
			for(int i=0; i<numero.Length; i++)
			{
				cifre[N - i - 1] = Convert.ToInt32(numero[i]) - '0';
			}
		}
		else
		{
			throw new InvalidOperationException();
		}
	}
}