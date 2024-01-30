using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

class Wages : Employee
{
    private double rate;
    private double hours;

    public Wages(string id, string name, string address, string phone, long sin, string dob, string dept, double Rate, double Hours) : base(id, name, address, phone, sin, dob, dept) 
    {
        this.rate = Rate;
        this.hours = Hours;
    }

    public double getPay()
    {
        return rate * hours;
    }

    public string getName()
    {
        return toName();
    }

    public string toString()
    {
        return ToStringMethod() + getPay();
    }

}