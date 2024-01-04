import { AppState } from "../AppState.js"
import { ToDo } from "../models/ToDo.js"
import { logger } from "../utils/Logger.js"
import { bcwSandbox } from "./AxiosService.js"

class ToDosService {
    async createToDo(toDoData) {
        const res = await bcwSandbox.post('api/todos', toDoData)
        logger.log('creating to do!', res.data)
        const newToDo = new ToDo(res.data)
        AppState.toDos.push(newToDo)
        return newToDo
    }
}
export const toDosService = new ToDosService()