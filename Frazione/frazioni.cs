namespace TestFrazioni
{
    class Program
    {
        static void Main(string[] args)
        {
            CFrazione f1, f2, r;
            f1 = new CFrazione(1,8);
            f2 = new CFrazione(7, 8);
            r = CFrazione.somma(f1, f2);
            Console.WriteLine("Frazione 1= {0} \nFrazione 2 = {1} \nRisultato = {2}", f1.ToString(), f2, r);
        }
    }
}

class CFrazione
{
    private int _num, _den;

    public int numeratore
    {
        get { return _num; }
        set { _num = value; }
    }
   
    public int denominatore    
    {
        get { return _den; }
        set
        {
            if (value != 0)
    			_den = value;
            else
                _den = 1;
        }
    }

    public CFrazione()  
    {
        numeratore = 0;
        denominatore = 1;
    }

    public CFrazione(int numeratore, int denominatore)    
    {
        this.numeratore = numeratore;
        this.denominatore = denominatore;
    }

    public override string ToString()
    {
        string risultato = "";
        risultato = this.numeratore.ToString() + "/" + this.denominatore.ToString();
        return risultato;
    }

    public static CFrazione somma(CFrazione f1, CFrazione f2)
    {
        CFrazione risultato = new CFrazione();
        if(f1.denominatore == f2.denominatore)
		{
			risultato.numeratore = f1.numeratore + f2.numeratore;
			risultato.denominatore = f1.denominatore;
		}else
		{
			risultato.denominatore = f1.denominatore * f2.denominatore;
        	risultato.numeratore = (risultato.denominatore / f1.denominatore) * f1.numeratore +
            	(risultato.denominatore / f2.denominatore) * f2.numeratore;
		}
        return risultato;
    }

    public CFrazione somma(CFrazione f1)
    {
        CFrazione risultato = CFrazione.somma(f1, this);
        return risultato;
    }
}