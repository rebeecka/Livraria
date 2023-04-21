﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Livraria.Migrations
{
    public partial class PopularLivros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Livros(CategoriaId,Autor,LongaDescricao,Disponivel,ImagemMiniUrl,ImagemUrl,LivroFavorito,Nome,Preco) VALUES(1,'Pão, hambúrger, ovo, presunto, queijo e batata palha','Delicioso pão de hambúrger com ovo frito; presunto e queijo de primeira qualidade acompanhado com batata palha',1, 'http://www.macoratti.net/Imagens/Livros/cheesesalada1.jpg','http://www.macoratti.net/Imagens/Livros/cheesesalada1.jpg', 0 ,'Cheese Salada', 12.50)");
            migrationBuilder.Sql("INSERT INTO Livros(CategoriaId,Autor,LongaDescricao,Disponivel,ImagemMiniUrl,ImagemUrl,LivroFavorito,Nome,Preco) VALUES(1,'Pão, presunto, mussarela e tomate','Delicioso pão francês quentinho na chapa com presunto e mussarela bem servidos com tomate preparado com carinho.',1,'http://www.macoratti.net/Imagens/Livros/mistoquente4.jpg','http://www.macoratti.net/Imagens/Livros/mistoquente4.jpg',0,'Misto Quente', 8.00)");
            migrationBuilder.Sql("INSERT INTO Livros(CategoriaId,Autor,LongaDescricao,Disponivel,ImagemMiniUrl,ImagemUrl,LivroFavorito,Nome,Preco) VALUES(1,'Pão, hambúrger, presunto, mussarela e batalha palha','Pão de hambúrger especial com hambúrger de nossa preparação e presunto e mussarela; acompanha batata palha.',1,'http://www.macoratti.net/Imagens/Livros/cheeseburger1.jpg','http://www.macoratti.net/Imagens/Livros/cheeseburger1.jpg',0,'Cheese Burger', 11.00)");
            migrationBuilder.Sql("INSERT INTO Livros(CategoriaId,Autor,LongaDescricao,Disponivel,ImagemMiniUrl,ImagemUrl,LivroFavorito,Nome,Preco) VALUES(2,'Pão Integral, queijo branco, peito de peru, cenoura, alface, iogurte','Pão integral natural com queijo branco, peito de peru e cenoura ralada com alface picado e iorgurte natural.',1,'http://www.macoratti.net/Imagens/Livros/Livronatural.jpg','http://www.macoratti.net/Imagens/Livros/Livronatural.jpg',1,'Livro Natural Peito Peru', 15.00)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Livros");
        }
    }
}