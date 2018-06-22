USE ugb_financeiro;

/*
* Seleciona o tipo e nome do curso a sua respectiva mensalidade
* Pega apenas as mensalidades cuja valor é superior à 1000
*/
SELECT t.Tipo, c.NomeCurso, m.ValorMensalidade FROM Mensalidade m
INNER JOIN Curso c ON c.idCurso = m.Curso_idCurso
INNER JOIN Tipo t ON t.idTipo = c.Tipo_idTipo
WHERE m.ValorMensalidade > 1000;
