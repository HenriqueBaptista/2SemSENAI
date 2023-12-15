import React from 'react';

const TableDEv = ({
    tituloTabela = "Tabela de comentários",
    dados,
    usuario,
    descricao,
    hideTable = true,
}) => {
    return (
        <table className="tbal-data">
            <h3>
                {tituloTabela}
                <span onClick={() => hideTable(true)}>X</span>
            </h3>

            <thead>
                <tr>
                    <th>Usuário</th>
                    <th>Feedback</th>
                </tr>
            </thead>

            <tbody>
                {dados.map((c) => {
                    return (
                        <tr>
                            <td>{usuario}</td>

                            <td>{descricao}</td>

                            {c.usuario.tipoUsuario.titulo === "Administrador" ?
                                <>
                                    <td>Exibe a todos: {c.exibe ?
                                        <>Sim</>
                                        :
                                        <>Não</>
                                    }
                                    </td>
                                </>
                                :
                                null
                            }
                        </tr>
                    )
                })}
            </tbody>
        </table>
    );
};

export default TableDEv;