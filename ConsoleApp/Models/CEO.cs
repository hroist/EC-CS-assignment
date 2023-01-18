namespace ConsoleApp.Models;

internal interface ICEO
{
    bool BeneficialOwner { get; set; }
}

internal class CEO : Employee, ICEO
{
    public bool BeneficialOwner { get; set; } = true;
}
