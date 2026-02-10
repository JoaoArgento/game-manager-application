import { GameDTO } from "../../types/GameDTO"
import {Pencil, Trash2} from "lucide-react";
type Props =  
{
    games: GameDTO[]
}

export default function GameCards(props : Props)
{
    return <div className="grid gap-4 sm:grid-cols-2 lg:grid-cols-4">

        {props.games?.map((game : GameDTO, index : number) =>
            {
                    return <div key = {index} className="group overflow-hidden rounded-xl border border-zinc-200 bg-white shadow-sm transition hover:-translate-y-0.5 hover:shadow-md">
                        <div className = "h-40 w-full bg-zinc-100">
                            {game.logoPath != "" &&  
                            <img src = {game.logoPath}
                            className = "h-full w-full object-cover"/>}
                        </div>
                        <div className = "p-4">
                            <h3 className = "text-lg font-semibold text-zinc-900">
                                {game.name}
                            </h3>
                        </div>

                        <p className="mt-1 mb-1 ml-2 text-md text-zinc-500">
                            {game.description}
                        </p>

                        <div className = "mt-4 flex items-center justify-end gap-2">
                            <button className = "inline-flex items-center justify-center rounded-lg border border-zinc-200 bg-white px-3 py-1.5 text-xs font-medium text-zinc-700 shadow-sm transition hover:bg-zinc-50 hover:text-zinc-900 focus:outline-none focus:ring-2 focus:ring-zinc-400">
                                <Pencil className="h-3.5 w-3.5"/>Editar
                            </button>

                            <button className="inline-flex items-center justify-center rounded-lg border border-red-200 bg-red-50 px-3 py-1.5 text-xs font-semibold text-red-700 shadow-sm transition hover:bg-red-100 focus:outline-none focus:ring-2 focus:ring-red-400">
                                <Trash2 className="h-3.5 w-3.5"/>Excluir
                            </button>
                        </div>
                    </div> 
            })
        }
    </div>
}