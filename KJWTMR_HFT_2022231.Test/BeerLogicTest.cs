using KJWTMR_HTF_2022231.Logic;
using KJWTMR_HTF_2022231.Logic.Interfaces;
using KJWTMR_HTF_2022231.Models;
using KJWTMR_HTF_2022231.Models.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Type = KJWTMR_HTF_2022231.Models.Type;

namespace KJWTMR_HFT_2022231.Test
{
    [TestFixture]
    public class BeerLogicTest
    {
        BeerLogic beerlogic;
        BrandLogic brandlogic;
        TypeLogic typelogic;
        Mock<IRepository<Beer>> mockBeerRepository;
        Mock<IRepository<Brand>> mockBrandRepository;
        Mock<IRepository<Type>> mockTypeRepository;

        [SetUp]
        public void Setup()
        {
          
            Brand fakeBrandSoproni = new Brand()
            {
                Id = 1,
                Name = "Soproni"
            };
            Brand fakeBrandBorsodi = new Brand()
            {
                Id = 2,
                Name = "Borsodi"
            };
            Type fakeTypeIpa = new Type()
            {
                Id = 1,
                TypeName = "Ipa",
                Alcohol_Content = 6
            };
            Type fakeTypeVilagos = new Type()
            {
                Id = 4,
                TypeName = "Világos sör",
                Alcohol_Content=4
            };
            var beers = new List<Beer>()
            {
                new Beer()
                {
                    Id = 15,
                    BrandId = fakeBrandSoproni.Id,
                    Price = 375,
                    Brand = fakeBrandSoproni,
                    Type = fakeTypeIpa,
                    TypeId = fakeTypeIpa.Id,
                },
                new Beer()
                {
                    Id = 16,
                    BrandId = fakeBrandSoproni.Id,
                    Price = 375,
                    Brand = fakeBrandSoproni,
                    Type = fakeTypeIpa,
                    TypeId = fakeTypeIpa.Id,
                },
                new Beer()
                {
                    Id = 17,
                    BrandId = fakeBrandBorsodi.Id,
                    Price = 300,
                    Brand = fakeBrandBorsodi,
                    Type = fakeTypeVilagos,
                    TypeId = fakeTypeVilagos.Id,
                }
            }.AsQueryable();
           
            mockBeerRepository = new Mock<IRepository<Beer>>();
            beerlogic = new BeerLogic(mockBeerRepository.Object);

            mockBrandRepository = new Mock<IRepository<Brand>>();
            brandlogic = new BrandLogic(mockBrandRepository.Object);

            mockTypeRepository = new Mock<IRepository<Type>>();
            typelogic = new TypeLogic(mockTypeRepository.Object);

            mockBeerRepository.Setup(r => r.ReadAll()).Returns(beers);
        }


        #region CreateTests
        [TestCase(1)]
        [TestCase(15)]
        public void CreateBeerTestCorrect(int id)
        {
            var beer = new Beer() { Id = id };

            //Act
            beerlogic.Create(beer);

            //Assert
            mockBeerRepository.Verify(r => r.Create(beer), Times.Once);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void CreateBeerTestInCorrect(int id)
        {
            var beer = new Beer() { Id = id };
            try
            {
                //Act
                beerlogic.Create(beer);
            }
            catch{ }
                      
            //Assert
            mockBeerRepository.Verify(r => r.Create(beer), Times.Never);
        }

        [TestCase(1)]
        [TestCase(8)]
        public void CreateBrandTestCorrect(int id)
        {
            var brand = new Brand() { Id = id };

            //Act
            brandlogic.Create(brand);

            //Assert
            mockBrandRepository.Verify(r => r.Create(brand), Times.Once);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void CreateBrandTestInCorrect(int id)
        {
            var brand = new Brand() { Id = id };
            try
            {
                //Act
                brandlogic.Create(brand);
            }
            catch { }

            //Assert
            mockBrandRepository.Verify(r => r.Create(brand), Times.Never);
        }

        [TestCase(1)]
        [TestCase(6)]
        public void CreateTypeTestCorrect(int id)
        {
            var type = new Type() { Id = id };

            //Act
            typelogic.Create(type);

            //Assert
            mockTypeRepository.Verify(r => r.Create(type), Times.Once);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void CreateTypeTestInCorrect(int id)
        {
            var type = new Type() { Id = id };
            try
            {
                //Act
                typelogic.Create(type);
            }
            catch { }

            //Assert
            mockTypeRepository.Verify(r => r.Create(type), Times.Never);
        }
        #endregion

        #region ReadTests
        //[TestCase(0)]
        //public void BeerReadTestCorrect(int id)
        //{
        //    var beer = new Beer() { Id = id };
        //    //Act
        //    beerlogic.Read(beer.Id);

        //    //Assert
        //    mockBeerRepository.Verify(r => r.Read(beer.Id), Times.Once);
        //}


        //[TestCase(0)]
        //[TestCase(0)]
        //public void BeerReadTestInCorrect(int id)
        //{
        //    var beer = new Beer() { Id = id };
        //    try
        //    {
        //        //Act
        //        beerlogic.Read(beer.Id);
        //    }
        //    catch { };

        //    //Assert
        //    mockBeerRepository.Verify(r => r.Read(beer.Id), Times.Never);
        //}
        #endregion

        #region OtherTests
        [Test]
        public void AVGPriceTest()
        {
            //Arrange --> Setup()
            double expected = 350;

            //Act
            var result = beerlogic.AVGPrice();

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }
        #endregion

        #region Non-CrudsTests

        [Test]
        public void BrandsAvgPriceTest()
        {
            var actual = beerlogic.BrandsAvgPrice().ToList();
            var expected = new List<BrandAvgPriceStatistics>()
            {
                new BrandAvgPriceStatistics()
                { Name = "Soproni", AvgPrice = 375 },
                new BrandAvgPriceStatistics()
                { Name = "Borsodi", AvgPrice = 300 }
            };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TypesAvgPriceTest()
        {
            var actual = beerlogic.TypesAvgPrice().ToList();
            var expected = new List<TypeAvgPriceStatistics>()
            {
                new TypeAvgPriceStatistics()
                { Name = "Ipa", AvgPrice = 375 },
                new TypeAvgPriceStatistics()
                { Name = "Világos sör", AvgPrice = 300 }
            };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void BrandsBeerCountTest()
        {
            var actual = beerlogic.BrandsBeerCount().ToList();
            var expected = new List<BrandsBeerCountStatistics>()
            {
                new BrandsBeerCountStatistics()
                { Name = "Soproni", BeerCount = 2 },
                new BrandsBeerCountStatistics()
                { Name = "Borsodi", BeerCount = 1 }
            };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TypesBeerCountTest()
        {
            var actual = beerlogic.TypesBeerCount().ToList();
            var expected = new List<TypesBeerCountStatistics>()
            {
                new TypesBeerCountStatistics()
                { Name = "Ipa", BeerCount = 2 },
                new TypesBeerCountStatistics()
                { Name = "Világos sör", BeerCount = 1 }
            };

            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
