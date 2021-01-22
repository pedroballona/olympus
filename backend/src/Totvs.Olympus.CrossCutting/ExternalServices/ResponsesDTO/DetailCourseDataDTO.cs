using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Totvs.Olympus.CrossCutting.ExternalServices.ResponsesDTO
{
  public partial class DetailCourseDataDto
  {
    [JsonProperty("showable")]
    public bool Showable { get; set; }

    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("slug")]
    public string Slug { get; set; }

    [JsonProperty("nome")]
    public string Nome { get; set; }

    [JsonProperty("metadescription")]
    public string Metadescription { get; set; }

    [JsonProperty("categoria")]
    public Categoria Categoria { get; set; }

    [JsonProperty("subcategoria")]
    public Subcategoria Subcategoria { get; set; }

    [JsonProperty("quantidade_aulas")]
    public long QuantidadeAulas { get; set; }

    [JsonProperty("minutos_video")]
    public long MinutosVideo { get; set; }

    [JsonProperty("nota")]
    public double Nota { get; set; }

    [JsonProperty("nota_disponivel")]
    public bool NotaDisponivel { get; set; }

    [JsonProperty("quantidade_avaliacoes")]
    public long QuantidadeAvaliacoes { get; set; }

    [JsonProperty("quantidade_alunos")]
    public long QuantidadeAlunos { get; set; }

    [JsonProperty("carga_horaria")]
    public long CargaHoraria { get; set; }

    [JsonProperty("quantidade_atividades")]
    public long QuantidadeAtividades { get; set; }

    [JsonProperty("data_criacao")]
    public DateTime? DataCriacao { get; set; }

    [JsonProperty("data_atualizacao")]
    public DateTime? DataAtualizacao { get; set; }

    [JsonProperty("video_1a_aula")]
    public Uri Video1AAula { get; set; }

    [JsonProperty("publico_alvo")]
    public string PublicoAlvo { get; set; }

    [JsonProperty("chamadas")]
    public string[] Chamadas { get; set; }

    [JsonProperty("ementa")]
    public Ementa[] Ementa { get; set; }

    [JsonProperty("instrutores")]
    public Instrutor[] Instrutores { get; set; }

    [JsonProperty("carreiras")]
    public object[] Carreiras { get; set; }

    [JsonProperty("musicas")]
    public object[] Musicas { get; set; }

    [JsonProperty("depoimentos")]
    public object[] Depoimentos { get; set; }

    [JsonProperty("formacoes")]
    public Formacao[] Formacoes { get; set; }

    [JsonProperty("curso_substituto")]
    public object CursoSubstituto { get; set; }

    [JsonProperty("requerimentos")]
    public string[] Requerimentos { get; set; }

    [JsonProperty("highlightedExtraField")]
    public string HighlightedExtraField { get; set; }

    [JsonProperty("transcriptions")]
    public Transcription[] Transcriptions { get; set; }
  }

  public partial class Categoria
  {
    [JsonProperty("nome")]
    public string Nome { get; set; }

    [JsonProperty("slug")]
    public string Slug { get; set; }

    [JsonProperty("ordem")]
    public long Ordem { get; set; }

    [JsonProperty("cor")]
    public object Cor { get; set; }

    [JsonProperty("cor_auxiliar")]
    public object CorAuxiliar { get; set; }

    [JsonProperty("subcategorias")]
    public object Subcategorias { get; set; }

    [JsonProperty("cursos")]
    public object Cursos { get; set; }

    [JsonProperty("numero_cursos")]
    public object NumeroCursos { get; set; }

    [JsonProperty("guides")]
    public object Guides { get; set; }
  }

  public partial class Ementa
  {
    [JsonProperty("capitulo")]
    public string Capitulo { get; set; }

    [JsonProperty("secoes")]
    public string[] Secoes { get; set; }
  }

  public partial class Formacao
  {
    [JsonProperty("codigo")]
    public string Codigo { get; set; }

    [JsonProperty("cor")]
    public string Cor { get; set; }

    [JsonProperty("titulo")]
    public string Titulo { get; set; }

    [JsonProperty("criteoId")]
    public string CriteoId { get; set; }

    [JsonProperty("totalCursosPublicados")]
    public long TotalCursosPublicados { get; set; }

    [JsonProperty("categoriaSlug")]
    public string CategoriaSlug { get; set; }
  }

  public partial class Instrutor
  {
    [JsonProperty("twitter")]
    public string Twitter { get; set; }

    [JsonProperty("linkedin")]
    public Uri Linkedin { get; set; }

    [JsonProperty("username")]
    public string Username { get; set; }

    [JsonProperty("githubProfileLink")]
    public string GithubProfileLink { get; set; }

    [JsonProperty("fotos")]
    public Dictionary<string, Uri> Fotos { get; set; }

    [JsonProperty("sobre")]
    public string Sobre { get; set; }

    [JsonProperty("nome")]
    public string Nome { get; set; }
  }

  public partial class Subcategoria
  {
    [JsonProperty("slug")]
    public string Slug { get; set; }

    [JsonProperty("nome")]
    public string Nome { get; set; }

    [JsonProperty("metaTitle")]
    public object MetaTitle { get; set; }

    [JsonProperty("metaDescription")]
    public object MetaDescription { get; set; }

    [JsonProperty("description")]
    public object Description { get; set; }

    [JsonProperty("guides")]
    public string Guides { get; set; }

    [JsonProperty("cursos")]
    public object[] Cursos { get; set; }
  }

  public partial class Transcription
  {
    [JsonProperty("sectionName")]
    public string SectionName { get; set; }

    [JsonProperty("taskName")]
    public string TaskName { get; set; }

    [JsonProperty("transcription")]
    public string TranscriptionTranscription { get; set; }

    [JsonProperty("videoUrl")]
    public Uri VideoUrl { get; set; }
  }
}
