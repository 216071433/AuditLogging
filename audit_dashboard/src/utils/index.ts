"use server"
import axios from "axios";
import https from "https";
/* eslint-disable @typescript-eslint/no-unused-vars */

export const fetchAuditLogs = async (page: number) => {
    try {
        const response = await axios.get(
            `https://localhost:44335/audit/logs`,
            { httpsAgent: new https.Agent({ rejectUnauthorized: false })}
        );
        console.log({response})

        return response
    } catch (error) {
        console.error("Error fetching audit logs:", error);
    }
  };