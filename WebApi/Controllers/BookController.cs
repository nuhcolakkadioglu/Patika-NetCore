using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DbOperations;
using WebApi.ViewModel;
using FluentValidation;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]s")]
    public class BookController : ControllerBase
    {

        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookController(BookStoreDbContext context, IMapper mapper = null)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBook()
        {

            var bookList = _context.Books.ToList();
            var result = _mapper.Map<List<BooksViewModel>>(bookList);
            return Ok(result);


        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _mapper.Map<BookDetailViewModel>(_context.Books.FirstOrDefault(m => m.Id == id));

            return Ok(result);
        }




        [HttpPost]
        public IActionResult Add(CreateBookModel model)
        {
            var book = _context.Books.FirstOrDefault(m => m.Title.Contains(model.Title.ToLower().ToLower()));

            if (book is not null)
                return BadRequest();


                CreateBookValidator validator = new CreateBookValidator();
                validator.ValidateAndThrow(model);
                ValidationResult validationResult = validator.Validate(model);

                var entity = _mapper.Map<Book>(model);
                _context.Books.Add(entity);
                _context.SaveChanges();
                return Created("", "kayıt eklendi");

        }

        [HttpPut]
        public IActionResult Update(UpdateBookModel model)
        {

            var entity = _mapper.Map<Book>(model);

            _context.Books.Update(entity);
            _context.SaveChanges();
            return NoContent();


        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Book book = _context.Books.FirstOrDefault(m => m.Id == id);

                if (book is null)
                {
                    return BadRequest("kitap yok");
                }


                _context.Books.Remove(book);
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}