using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using VideoClub.Application.Services;
using VideoClub.Persistence.Repositories;
using VideoClub.Persistence;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using VideoClub.Application.Dependencies;
using VideoClub.Domain.Services;
using VideoClub.Application.Services.Interfaces;

namespace VideoClub.Presentation
{
	public class Startup
	{
		private readonly IConfiguration _configuration;

		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddAutoMapper(typeof(MovieMapper));
			services.AddAutoMapper(typeof(CustomerMapper));
			services.AddAutoMapper(typeof(GenreMapper));
			services.AddDbContext<VideoClubDbContext>(options =>
			 {
				 options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("VideoClub.Persistence"));
			 });

			services.AddControllers().AddNewtonsoftJson(options =>
				options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
			);
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "VideoClub.Presentation", Version = "v1" });
			});

			services.AddTransient<IMovieRentalService, MovieRentalService>();
			services.AddTransient<ITransactionService, TransactionService>();

			services.AddScoped<IMovieRepository, MovieRepository>();
			services.AddScoped<IRentalRepository, RentalRepository>();
			services.AddScoped<MovieService>();
			
			services.AddScoped<IGenreRepository, GenreRepository>();
			services.AddScoped<GenreService>();
			services.AddScoped<ICustomerRepository, CustomerRepository>();
			services.AddScoped<CustomerService>();
			services.AddScoped<VideoClubDbContext>();

			services.AddScoped<RatingService>();
			services.AddScoped<IMovieRateService,MovieRateService>();
			services.AddScoped<IRatingRepository,RatingRepository>();


			
		}


		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VideoClub.Presentation v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
