using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

class Salaried : Employee
{
    private double salary;

    public Salaried(string id, string name, string address, string phone, long sin, string dob, string dept, double Salary) : base(id, name, address, phone, sin, dob, dept) 
    {
        this.salary = Salary;
    }

    public double getPay()
    {
        return salary;
    }

    public string getName()
    {
        return toName();
    }

    public string toString()
    {
        return ToStringMethod() + $" {this.salary}";
    }

}