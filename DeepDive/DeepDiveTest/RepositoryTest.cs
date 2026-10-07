using DeepDive.Data;
using DeepDive.Models;
using DeepDive.Persistance;
using Microsoft.EntityFrameworkCore;
namespace DeepDiveTest;

[TestClass]
public class RepositoryTest
{
    private TankRepository CreateRepo(string dbName)
    {
        var options = new DbContextOptionsBuilder<EquipmentContext>()
            .UseInMemoryDatabase(dbName)
            .Options;

        var context = new EquipmentContext(options);
        return new TankRepository(context);
    }
    private Tank CreateTank(int id)
    {
        return new Tank { TankId = id, Brand = "TestBrand", Volumen = 12, Price = 100 };
    }

    [TestMethod]
    public async Task AddNewTank_Issaved()
    {
        var repo = CreateRepo("AddTest");

       await repo.Add(CreateTank(1));

        Assert.IsNotNull( await repo.GetById(1));
    }
    [TestMethod]
    public async Task GetAll_TwoTanks_ReturnsTwo()
    {
        var repo = CreateRepo("GetAllTest");
        await repo.Add(CreateTank(1));
       await  repo.Add(CreateTank(2));

        var result = await repo.GetAll();

        Assert.AreEqual(2, result.Count);
    }

    [TestMethod]
    public async Task GetById_UnknownId_ReturnsNull()
    {
        var repo = CreateRepo("GetByIdTest");

        var result = await repo.GetById(123);

        Assert.IsNull(result);
    }

    [TestMethod]
    public async Task Update_ChangeBrand_IsSaved()
    {
        var repo = CreateRepo("UpdateTest");
        var tank = CreateTank(1);
        await repo.Add(tank);

        tank.Brand = "NewBrand";
       await repo.Update(tank);

        Assert.AreEqual("NewBrand",( await repo.GetById(1))!.Brand);
    }

    [TestMethod]
    public async Task Delete_ExistingTank_IsRemoved()
    {
        var repo = CreateRepo("DeleteTest");
        await repo.Add(CreateTank(1));

        await repo.Delete(1);

        Assert.IsNull(await repo.GetById(1));
    }

    [TestMethod]
    public async Task Delete_UnknownId_DoesNotCrash()
    {
        var repo = CreateRepo("DeleteUnknownTest");

       await repo.Delete(123);   // should just do nothing

        Assert.AreEqual(0, (await repo.GetAll()).Count);
    }
}


