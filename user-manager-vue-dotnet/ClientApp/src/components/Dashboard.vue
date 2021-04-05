<template>
  <div>
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1>Dashboard</h1>
          </div>
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item">
                <a>Home</a>
              </li>
            </ol>
          </div>
        </div>
      </div>
      <!-- /.container-fluid -->
    </section>

    <!-- Main content -->
    <section class="content pt-3 px-2">
      <div class="container-fluid">
        <!-- Small boxes (Stat box) -->
        <div class="row">
          <div class="col-lg-3 col-6">
            <!-- small box -->
            <div class="small-box bg-info">
              <div class="inner">
                <h3>150</h3>

                <p>New Orders (placeholder)</p>
              </div>
              <div class="icon">
                <i class="ion ion-bag"></i>
              </div>
              <a href="#" class="small-box-footer">
                More info
                <i class="fas fa-arrow-circle-right"></i>
              </a>
            </div>
          </div>
          <!-- ./col -->
          <div class="col-lg-3 col-6">
            <!-- small box -->
            <div class="small-box bg-success">
              <div class="inner">
                <h3>
                  53
                  <sup style="font-size: 20px">%</sup>
                </h3>

                <p>Bounce Rate (placeholder)</p>
              </div>
              <div class="icon">
                <i class="ion ion-stats-bars"></i>
              </div>
              <a href="#" class="small-box-footer">
                More info
                <i class="fas fa-arrow-circle-right"></i>
              </a>
            </div>
          </div>
          <!-- ./col -->
          <div class="col-lg-3 col-6">
            <!-- small box -->
            <div class="small-box bg-danger">
              <div class="inner">
                <h3>{{ users.length }}</h3>

                <p>User Registrations (active)</p>
              </div>
              <div class="icon">
                <i class="ion ion-person-add"></i>
              </div>
              <router-link :to="{ name: 'Users' }" class="small-box-footer">
                More info
                <i class="fas fa-arrow-circle-right"></i>
              </router-link>
            </div>
          </div>
          <!-- ./col -->
          <div class="col-lg-3 col-6">
            <!-- small box -->
            <div class="small-box bg-danger">
              <div class="inner">
                <h3>65</h3>

                <p>Unique Visitors (placeholder)</p>
              </div>
              <div class="icon">
                <i class="ion ion-pie-graph"></i>
              </div>
              <a href="#" class="small-box-footer">
                More info
                <i class="fas fa-arrow-circle-right"></i>
              </a>
            </div>
          </div>
          <!-- ./col -->
        </div>
        <!-- /.row -->
      </div>
      <!-- /.container-fluid -->
    </section>
    <!-- /.content -->
  </div>
</template>

<script>
import UsersService from '../_services/users-service';
export default {
  data() {
    return {
      users: [],
    };
  },
  beforeMount() {
    UsersService.getAll().then((users) => {
      this.users = users;
      console.log(users);
    });
  }
};
</script>