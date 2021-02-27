import Vue from 'vue'
import axios from 'axios'

const client = axios.create({
  baseURL: '/api/Users',
  json: true
})

export default {
  async execute(method, resource, data) {
    const accessToken = await Vue.prototype.$auth.getAccessToken()
    return client({
      method,
      url: resource,
      data,
      headers: {
        Authorization: `Bearer ${accessToken}`
      }
    })
      .then(response => {
        return response.data
      })
      .catch(error => {
        alert(error);
      })
  },
  getAll() {
    return this.execute('get', '/')
  },
  create(data) {
    return this.execute('post', '/', data)
  },
  update(id, data) {
    return this.execute('put', `/${id}`, data)
  },
  delete(id) {
    return this.execute('delete', `/${id}`)
  }
}