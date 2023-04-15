class CFrazione
{
	private int _num, _den;

	public int num
	{
		get { return _num; }
		set { _num = value; }
	}

	public int den
	{
		get { return _den; }
		set { _den = (value != 0) ? value : 1; }
	}

	public CFrazione()
	{
		num = 0;
		den = 0;
	}

	public CFrazione(int den, int denom)
	{
		this.num = den;
		this.den = denom;
	}

	public override string ToString()
	{
		string result = "";
		result = this.num.ToString() + "/" + this.den.ToString();
		return result;
	}

	public static CFrazione operator +(CFrazione f1, CFrazione f2)
	{
		return somma(f1, f2);
	}
	public static CFrazione operator -(CFrazione f1, CFrazione f2)
	{
		return sottrazione(f1, f2);
	}
	public static CFrazione operator *(CFrazione f1, CFrazione f2)
	{
		return moltiplicazione(f1, f2);
	}
	public static CFrazione operator /(CFrazione f1, CFrazione f2)
	{
		return divisione(f1, f2);
	}

	public CFrazione inverti()
	{
		CFrazione result = new CFrazione();
		result.num = this.den;
		result.den = this.num;
		return result;
	}
	
	public static CFrazione somma(CFrazione f1, CFrazione f2)
	{
		CFrazione result = new CFrazione();
		result.den = f1.den * f2.den;
		result.num = (result.den / f1.den) * f1.num +
			(result.den / f2.den) * f2.num;
		return result;
	}

	public CFrazione somma(CFrazione f)
	{
		CFrazione result = CFrazione.somma(f, this);
		return result;
	}

	public static CFrazione sottrazione(CFrazione f1, CFrazione f2)
	{
		CFrazione result = new CFrazione();
		result.den = f1.den * f2.den;
		result.num = (result.den / f1.den) * f1.num - (result.den / f2.den) * f2.num;
		return result;
	}
	public CFrazione sottrazione(CFrazione f)
	{
		CFrazione result = sottrazione(f, this);
		return result;
	}
	public static CFrazione moltiplicazione(CFrazione f1, CFrazione f2)
	{
		CFrazione result = new CFrazione();
		result.den = f1.den * f2.den;
		result.num = f1.num * f2.num;
		return result;
	}
	public CFrazione moltiplicazione(CFrazione f)
	{
		CFrazione result = sottrazione(f, this);
		return result;
	}
	public static CFrazione divisione(CFrazione f1, CFrazione f2)
	{
		f2 = f2.inverti();
		CFrazione result = moltiplicazione(f1, f2);
		return result;
	}
	public CFrazione divisione(CFrazione f)
	{
		CFrazione result = new CFrazione();
		result = divisione(this, f);
		return result;
	}
}