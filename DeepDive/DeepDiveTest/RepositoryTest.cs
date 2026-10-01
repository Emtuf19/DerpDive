using DeepDive.Data;
using DeepDive.Models;
using DeepDive.Persistance;
using Microsoft.EntityFrameworkCore;
namespace DeepDiveTest;

[TestClass]
public class RepositoryTest
{
    //private TankRepository CreateRepo(string dbName)
    //{
    //    var options = new DbContextOptionsBuilder<EquipmentContext>()
    //        .UseInMemoryDatabase(dbName)
    //        .Options;

    //    var context = new EquipmentContext(options);
    //    return new TankRepository(context);
    //}
    //private Tank CreateTank(int id)
    //{
    //    return new Tank { TankId = id, Brand = "TestBrand", Volumen = 12, Price = 100 };
    //}

    //[TestMethod]
    //public void AddNewTank_Issaved()
    //{
    //    var repo = CreateRepo("AddTest");

    //    repo.Add(CreateTank(1));

    //    Assert.IsNotNull(repo.GetById(1));
    //}
    //[TestMethod]
    //public void GetAll_TwoTanks_ReturnsTwo()
    //{
    //    var repo = CreateRepo("GetAllTest");
    //    repo.Add(CreateTank(1));
    //    repo.Add(CreateTank(2));

    //    var result = repo.GetAll();

    //    Assert.AreEqual(2, result.Count);
    //}

    //[TestMethod]
    //public void GetById_UnknownId_ReturnsNull()
    //{
    //    var repo = CreateRepo("GetByIdTest");

    //    var result = repo.GetById(123);

    //    Assert.IsNull(result);
    //}

    //[TestMethod]
    //public void Update_ChangeBrand_IsSaved()
    //{
    //    var repo = CreateRepo("UpdateTest");
    //    var tank = CreateTank(1);
    //    repo.Add(tank);

    //    tank.Brand = "NewBrand";
    //    repo.Update(tank);

    //    Assert.AreEqual("NewBrand", repo.GetById(1)!.Brand);
    //}

    //[TestMethod]
    //public void Delete_ExistingTank_IsRemoved()
    //{
    //    var repo = CreateRepo("DeleteTest");
    //    repo.Add(CreateTank(1));

    //    repo.Delete(1);

    //    Assert.IsNull(repo.GetById(1));
    //}

    //[TestMethod]
    //public void Delete_UnknownId_DoesNotCrash()
    //{
    //    var repo = CreateRepo("DeleteUnknownTest");

    //    repo.Delete(123);   // should just do nothing

    //    Assert.AreEqual(0, repo.GetAll().Count);
    //}
}


