import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { KpiCardComponent } from './components/kpi-card/kpi-card.component';
import { ChartContainerComponent } from './components/chart-container/chart-container.component';
import { ActivityFeedComponent } from './components/activity-feed/activity-feed.component';
import { RevenueChartComponent } from './charts/revenue-chart/revenue-chart.component';
import { UserChartComponent } from './charts/user-chart/user-chart.component';

@NgModule({
  declarations: [
    AppComponent,
    KpiCardComponent,
    ChartContainerComponent,
    ActivityFeedComponent,
    RevenueChartComponent,
    UserChartComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
