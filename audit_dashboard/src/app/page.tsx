'use client'
/* eslint-disable @typescript-eslint/no-unused-vars */
import { useState, useEffect } from "react";
import axios from "axios";
// import { useTable, usePagination, useSortBy } from "@tanstack/react-table";
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";
import { Card, CardContent } from "@/components/ui/card";
import { fetchAuditLogs } from "@/utils";

export default function Home() {

  const [data, setData] = useState([]);
  const [loading, setLoading] = useState(true);
  const [filter, setFilter] = useState("");

  
  useEffect(() => {
    const fetchLogs = async () => {
      setLoading(true);
      try {
        console.log("Fetching audit logs...");
        const data = await fetchAuditLogs(1);
        console.log("Fetched logs:", data?.status);

        // ✅ Prevent unnecessary re-renders
        setData(data?.data);
      } catch (error) {
        console.error("Error fetching audit logs:", error);
      }
      setLoading(false);
    };

    fetchLogs();
}, [data]);
  
  return (
    <div className="flex">
      <h1>Audit Logs</h1>
    </div>
  );
}
