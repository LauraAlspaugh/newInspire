import { AppState } from "../AppState.js"
import { ToDo } from "../models/ToDo.js"
import { logger } from "../utils/Logger.js"
import { api, bcwSandbox } from "./AxiosService.js"

class ToDosService {
    async createToDo(toDoData) {
        const res = await api.post('api/todos', toDoData)
        logger.log('creating to do!', res.data)
        const newToDo = new ToDo(res.data)
        AppState.toDos.push(newToDo)
        return newToDo
    }
    async getToDos() {
        const res = await api.get('api/todos')
        logger.log('getting todos', res.data)
        AppState.toDos = res.data.map(pojo => new ToDo(pojo))
    }
}
export const toDosService = new ToDosService()