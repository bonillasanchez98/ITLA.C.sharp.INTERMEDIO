using BiblioCleanSol.Application.Dtos.Libros.Categoria;
using BiblioCleanSol.Domain.Entities.Libros;

namespace BiblioCleanSol.Application.Extentions.Libros
{
    public static class CategoriaExtention
    {
        public static Categoria ToCategoriaEntityFromCategoriaDtoAgregar(CategoriaDto categoriaDto)
        {
            return new Categoria
            {
                Nombre = categoriaDto.Nombre,
                Descripcion = categoriaDto.Descripcion
            };
        }

        public static Categoria ToCategoriaEntityFromCategoriaDtoEditar(CategoriaEditarDto categoriaEditarDto)
        {
            return new Categoria
            {
                CategoraId = categoriaEditarDto.CategoriaId,
                Nombre = categoriaEditarDto.Nombre,
                Descripcion = categoriaEditarDto.Descripcion,
                Habilitado = categoriaEditarDto.Habilitado
            };
        }

        public static CategoriaDto ToCategoriaDtoFromCategoriaEntity(Categoria categoria)
        {
            return new CategoriaDto
            {
                Nombre = categoria.Nombre,
                Descripcion= categoria.Descripcion
            };
        }
    }
}
