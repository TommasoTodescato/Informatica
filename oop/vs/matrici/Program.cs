namespace matrici
{
    internal class Program
    {
        static void Main(string[] args)
        {
            matrix m1 = new matrix(2, 3, true, 0, 5);
            matrix m2 = new matrix(3, 2, true, 0, 5);

            m1.print();
            Console.WriteLine("*");
            m2.print();
            Console.WriteLine("=");

            m1.dot_product(m2);
            m1.print();
            Console.WriteLine(m1.determinant());
        }
    }
}