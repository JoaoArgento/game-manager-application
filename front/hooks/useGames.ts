import {useQuery, useMutation, useQueryClient} from "@tanstack/react-query";
import gameService from "../services/GameService";
import { CreateGameDTO, GameDTO } from "../types/GameDTO";

const QUERY_KEY = ["games"]

export function useGames()
{
    return useQuery<GameDTO[]>({
        queryKey: QUERY_KEY,
        queryFn: gameService.getAll
    });
}

export function useCreateGame()
{
    const queryClient = useQueryClient();

    return useMutation({
        mutationFn: (payload: CreateGameDTO) => gameService.createGame(payload),
        onSuccess: () => queryClient.invalidateQueries({queryKey: QUERY_KEY})
    });
}

export function useDeleteGame()
{
    const queryClient = useQueryClient();

    return useMutation({
        mutationFn: (id : string) => gameService.deleteGame(id),
        onSuccess: () => queryClient.invalidateQueries({queryKey: QUERY_KEY})
    })
}
