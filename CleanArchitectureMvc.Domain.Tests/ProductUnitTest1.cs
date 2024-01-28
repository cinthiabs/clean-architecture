using CleanArchitectureMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchitectureMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Produt Name", "Product Description",9, 99, "product image");
            action.Should()
                  .NotThrow<CleanArchitectureMvc.Domain.Validation.DomainExceptionValidation>();

        }
        [Fact(DisplayName = "Create Product With Invalid Id")]
        public void CreateProduct_NegativeIdValue_InvalidId()
        {
            Action action = () => new Product(-1, "Produt Name", "Product Description", 9, 99, "product image");
            action.Should()
                  .Throw<CleanArchitectureMvc.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid Id Value");

        }
        [Fact(DisplayName = "Create Product With Short Name")]
        public void CreateProduct_With_ShortName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9, 99, "product image");
            action.Should()
                  .Throw<CleanArchitectureMvc.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid name, too short, minimum 3 charecters.");

        }
        [Fact(DisplayName = "Create Product With Long Image Name")]
        public void CreateProduct_With_Long_Image()
        {
            Action action = () => new Product(1, "Produt Name", "Product Description", 9, 99, "product image loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooong");
            action.Should()
                  .Throw<CleanArchitectureMvc.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid name, too long, maximum 250 charecters.");

        }
        [Fact(DisplayName = "Create Product With Image Null")]
        public void CreateProduct_With_Image_Null()
        {
            Action action = () => new Product(1, "Produt Name", "Product Description", 99, 99, null);
            action.Should()
                  .NotThrow<CleanArchitectureMvc.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact(DisplayName = "Create Product With Image Null Reference Exeption")]
        public void CreateProduct_With_Image_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Produt Name", "Product Description", 99, 99, null);
            action.Should()
                  .NotThrow<NullReferenceException>();
        }
    }
}
