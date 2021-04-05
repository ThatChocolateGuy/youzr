import { authHeader } from "../_helpers/auth-header";

const _BASE_PATH = `/api/users`;

export default {
  authHeader,
  async getAll() {
    const requestOptions = {
      method: "GET",
      headers: authHeader()
    };

    try {
      const response = await fetch(`${_BASE_PATH}`, requestOptions);
      return handleResponse(response);
    } catch (error) {
      console.log(error);
    }
  },
  async getUser(id) {
    const requestOptions = {
      method: "GET",
      headers: authHeader()
    };

    try {
      const response = await fetch(`${_BASE_PATH}/${id}`, requestOptions);
      return handleResponse(response);
    } catch (error) {
      console.log(error);
    }
  },
  // create(data) {
  //   
  // },
  update(id, data) {
    const requestBody = {
      userId: id,
      email: data.emailInput,
      password: data.passwordInput,
      name: data.nameInput,
    }

    const requestOptions = {
      method: "PUT",
      headers: authHeader(),
      body: JSON.stringify(requestBody)
    };

    try {
      fetch(`${_BASE_PATH}/update/${id}`, requestOptions).then((res) => {
        console.log(res);
        data.$router.push('/users');
      })
        .error((err) => console.log(err));
    }
    catch (error) {
      console.log(error);
    }
  },
  delete(id) {
    const requestOptions = {
      method: "DELETE",
      headers: authHeader()
    };

    fetch(`${_BASE_PATH}/${id}`, requestOptions).then((response) => {
      const user = handleResponse(response);
      alert(`User ${user.name} deleted!`);
      return user;
    });
  },
  async login(username, password) {
    const requestOptions = {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ username, password })
    };

    const response = await fetch(`${_BASE_PATH}/authenticate`, requestOptions);
    const user = await handleResponse(response);
    // login successful if there's a user in the response
    if (user) {
      // store user details and basic auth credentials in local storage
      // to keep user logged in between page refreshes
      user.authdata = window.btoa(username + ":" + password);
      localStorage.setItem("user", JSON.stringify(user));
    }
    return user;
  },
  logout() {
    _logout();
  },
  async seedUsers() {
    const requestOptions = {
      method: "GET",
      headers: authHeader()
    };

    const response = await fetch(`${_BASE_PATH}/seedusers`, requestOptions);
    return handleResponse(response);
  },
}

function _logout() {
  // remove user from local storage to log user out
  localStorage.removeItem("user");
  console.log('logout called');
}

function isJson(_data) {
  try { JSON.parse(_data) } // Valid JSON
  catch { return false } // It is text
  return true;
}

function handleResponse(response) {
  try {
    return response.text().then(text => {
      console.log(response)
      console.log(text)
      let data = isJson(text) ? JSON.parse(text) : text;

      if (!response.ok) {
        if (response.status === 401) {
          // auto logout if 401 response returned from api
          _logout();
          window.location.reload();
        }

        const error = (data && data.message) || response.statusText;
        console.log(`error retrieving data`);
        return Promise.reject(error);
      }

      return data;
    });
  }
  catch (error) {
    console.log(`error: ${error}`);
    console.log(`response: ${response}`);
    return error;
  }
}