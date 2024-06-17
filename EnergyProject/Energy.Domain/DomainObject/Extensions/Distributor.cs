using Energy.Domain.DomainObject;

namespace Energy.Domain.Entities;

public partial class Distributor
{
    public Distributor(int id, string description, string code, bool active, DateTime dateCreate)
    {
        this.Id = id;
        this.Description = description;
        this.Code = code;
        this.Active = active;
        this.DateCreate = dateCreate;

        IsValid();
    }

    public void IsValid()
    {
        Validations.ValidIsNullOrWhiteSpace(Description, "A Descrição não deve ser vazia ou nula.");
        Validations.ValidIsNullOrWhiteSpace(Code, "A Sigla não deve ser vazia ou nula.");

        if (Id == 0 && Active == false)
            Validations.ValidIsFalse(Active, "Não é possivel cadastrar um registro com status desativado.");
    }
}
